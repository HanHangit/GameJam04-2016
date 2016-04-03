using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJam
{
    class CivilRequest
    {
        public Building requestingBuilding { get; private set; }
        public Building requestedBuilding { get; private set; }
        public List<Ressource> BauStoffe { get; private set; }
        public int requestTyp { get; private set; } // 0 to upgrade; 1 to build new;
        public int requestPriority;

        private String[] newBuildingTypes = {"Wohnhaus"};

        // new BuildingRequest
        public CivilRequest(Building _requestingBuilding, Building _requestedBuilding, int requestPriority)
        {
            requestTyp = 1;
            findRessourcesNeeded(_requestedBuilding);
        }

        // new BuildingRequest
        public CivilRequest(Building _requestingBuilding, int requestPriority)
        {
            requestTyp = 0;
        }

        void findRessourcesNeeded(Building building)
        {
            
            if(this.requestTyp == 1)
            {
                // finds Index of building in newBuildingTypes
                int numberOfString = -1;
                for(int i = 0; i < newBuildingTypes.Length; i++)
                {
                    if(newBuildingTypes[i] == building.name)
                    {
                        numberOfString = i;
                        break;
                    }
                }
                // switch(case) changes 
                switch(numberOfString)
                {
                    //case 0:  BauStoffe.Add(new Ressource()); break;
                    default: throw new Exception("Building doesnt Exist in newBuildintTypes"); 
                }
                
            }
            
        }

    }
}
