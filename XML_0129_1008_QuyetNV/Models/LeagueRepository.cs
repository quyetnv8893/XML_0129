using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using PlayerManagement.Models;

namespace PlayerManagement.Models
{
    public class LeagueRepository : ILeagueRepository
    {
        private List<League> allLeagues;
        private XDocument LeagueData;
        private String xml_path = "~/App_Data/player_management.xml";

        /**
         * Contructor to get all matches from xml file and save them to allMatches List
         **/
        public LeagueRepository()
        {
            allLeagues = new List<League>();
            LeagueData = XDocument.Load(HttpContext.Current.Server.MapPath(xml_path));
            var Leagues = from league in LeagueData.Descendants("league")
                          select new League(league.Element("name").Value,league.Element("logoLink").Value);
            allLeagues.AddRange(Leagues.ToList<League>());            
        }


        /**
         * Return list of Leagues
         **/
        public IEnumerable<League> GetLeagues()
        {
            return allLeagues;
        }

        /**
         * Get League by id
         **/ 
        public League GetLeagueByID(String name)
        {
            return allLeagues.Find(item => item.name.Equals(name));
        }
               
        /**
         * Insert new league
         **/
        public void InsertLeague(League league)
        {                        
            LeagueData.Descendants("matches").FirstOrDefault().Add(new XElement("match", new XElement("id", match.id),
                new XElement("time", match.time), new XElement("name", match.name), new XElement("score", match.score),
                new XElement("leagueName", match.leagueName)));
            LeagueData.Save(HttpContext.Current.Server.MapPath(xml_path));
        }

        /**
         * Delete a match which it's id
         **/ 
        public void DeleteMatch(String id)
        {
            LeagueData.Descendants("matches").Elements("match").Where(item => item.Element("id").Value.Equals(id)).Remove();
            LeagueData.Save(HttpContext.Current.Server.MapPath(xml_path));
        }
       
        
        /**
         * Edit a match which it's id
         **/ 
        public void EditMatch(Match Match)
        {
            
            XElement node = LeagueData.Descendants("matches").Elements("match").Where(item => item.Element("id").Value.Equals(Match.id)).FirstOrDefault();            
            node.SetElementValue("id", Match.id);
            node.SetElementValue("time", Match.time);            
            node.SetElementValue("name", Match.name);            
            node.SetElementValue("score", Match.score);
            node.SetElementValue("leagueName", Match.leagueName);
            LeagueData.Save(HttpContext.Current.Server.MapPath(xml_path));
        }

    }
}