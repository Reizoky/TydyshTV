using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Data;
using System.Text.RegularExpressions;
using System.Text;

namespace TheTydyshTV_Bot
{
    /// <summary>
    /// Персонаж
    /// </summary>
    class Character
    {
        public int health = 100;
        public int strength = 5;
        public int evasion = 5;
        public int block = 5;
        public int fortune = 5;
        public int coins = 0;
        public int fatigue = 0; //усталость 
        public string characterName = string.Empty;
        public List<string[]> equipmentList = new List<string[]>();
        public Dictionary<string, string> equipmentDic = new Dictionary<string, string>();
        public List<string[]> bufsList = new List<string[]>(); //список бафов
        public List<string[]> debufsList = new List<string[]>(); //список дебафов

        public Character(string _name)
        {
            characterName = _name;
            GetCharacterStats();
        }

        public void GetCharacterStats()
        {
            string sqlGetEqquipment = @"Select `Character`.`IdCharacter`, `Character`.`Name`, `Character`.`Description`,
`Equipment`.`Health`,
`Equipment`.`Strength`,
`Equipment`.`Evasion`,
`Equipment`.`Block`,
`Equipment`.`Fortune`,
`Character`.`Coins`, 
`Equipment`.`NameEquipment`,
`Equipment`.`Sex`,
`Equipment`.`Type`,
`Equipment_Prefix`.`Rare`,
`Equipment_Prefix`.`Prefix`,
`Equipment_Prefix`.`InHonor`,
`Character_Equipment`.`Taken`,
concat(
if (`Equipment_Prefix`.`Rare` != 'Обычный', concat(`Equipment_Prefix`.`Prefix`, ' '), '')
,  `Equipment`.`NameEquipment`) as 'NameEqPref'

                                                     
from `Character` left join `Character_Equipment` on `Character`.IdCharacter = `Character_Equipment`.IdCharacter
left join `Equipment` on `Character_Equipment`.IdEquipment = `Equipment`.IdEquipment
left join `Equipment_Prefix` on `Equipment_Prefix`.`IdEquipmentPrefix` = `Character_Equipment`.IdEquipmentPrefix
where `Character`.`Name` = '" + characterName + @"' and `Taken` = true
union
select `Character`.`IdCharacter`, `Character`.`Name`, `Character`.`Description`,
(`Character`.`Health`) as 'Health',
(`Character`.`Strength`) as 'Strength',
(`Character`.`Evasion`) as 'Evasion',
(`Character`.`Block`) as 'Block',
(`Character`.`Fortune`) as 'Fortune',
`Character`.`Coins`, 
null,
null,
null,
null,
null,
null,
null,
null
from `Character`
where `Character`.`Name` = '" + characterName + "';";
            WorkWithMYSQL sqlClient = new WorkWithMYSQL();
            DataTable dtEquipmentAndStats = sqlClient.GetTableFromDB(sqlGetEqquipment);
            try
            {
                if (dtEquipmentAndStats.Rows.Count != 0)
                {
                    health = 0;
                    strength = 0;
                    evasion = 0;
                    block = 0;
                    fortune = 0;
                    foreach (DataRow dr in dtEquipmentAndStats.Rows)
                    {
                        if (dr["Health"] == null)
                            continue;
                        health += Convert.ToInt32(dr["Health"]);
                        strength += Convert.ToInt32(dr["Strength"]);
                        evasion += Convert.ToInt32(dr["Evasion"]);
                        block += Convert.ToInt32(dr["Block"]);
                        fortune += Convert.ToInt32(dr["Fortune"]);
                        coins = Convert.ToInt32(dr["Coins"]);
                    }
                }

                List<string[]> patternsSex = new List<string[]>(){
                    new string[]{ "ий$", "ая" },
                    new string[] { "ый$", "ая" },
                    new string[] { "ой$", "ая" },
                    new string[] { "ийся$", "аяся" },};
                string eqPrefix = "";

                foreach (DataRow dr in dtEquipmentAndStats.Rows)
                    if (dr["NameEquipment"].ToString() != string.Empty)
                    {
                        eqPrefix = dr["Prefix"].ToString();
                        if (dr["InHonor"].ToString() == "1")
                        {
                            eqPrefix += "'s";
                        }
                        else if (dr["Sex"].ToString() == "f")
                        {
                            foreach (string[] pattern in patternsSex)
                            {
                                if (Regex.IsMatch(eqPrefix, pattern[0]))
                                {
                                    eqPrefix = Regex.Replace(eqPrefix, pattern[0], pattern[1]);
                                    break;
                                }
                            }
                        }
                        eqPrefix += (eqPrefix == "" ? "" : " ") + dr["NameEquipment"].ToString();
                        equipmentList.Add(new string[] { dr["NameEquipment"].ToString(), dr["Type"].ToString(), dr["Rare"].ToString(),
                        dr["Prefix"].ToString(), eqPrefix});
                        equipmentDic.Add(dr["Type"].ToString(), eqPrefix);
                    }
            }
            catch (Exception ex)
            {
                WriteError.WriteErrorIntoFile("Character - TargetSite" + ex.TargetSite + Environment.NewLine +
                    "Message - " + ex.Message + Environment.NewLine + "Source - " + ex.Source );
                return;
            }
        }
    }
}