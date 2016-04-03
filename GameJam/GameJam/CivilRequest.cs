using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJam
{
    class CivilRequest
    {
        public CivilBuilding requestingBuilding { get; private set; }
        public CivilBuilding requestedBuilding { get; private set; }
        public List<Ressource> BauStoffe { get; private set; }
        public int requestTyp { get; private set; } // 0 to upgrade; 1 to build new;
        public int requestPriority;

        private String[] newBuildingTypes = {"WohnHaus"};

        // new BuildingRequest
        public CivilRequest(CivilBuilding _requestingBuilding, CivilBuilding _requestedBuilding, int requestPriority)
        {
            requestingBuilding = _requestingBuilding;
            requestedBuilding = _requestedBuilding;
            requestPriority = 1;
            requestTyp = 1;
            findRessourcesNeeded(_requestedBuilding);
        }

        // new BuildingRequest
        public CivilRequest(CivilBuilding _requestingBuilding, int requestPriority)
        {
            requestTyp = 0;
        }

        void findRessourcesNeeded(CivilBuilding building)
        {
            BauStoffe = new List<Ressource>();
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
                    case 0:  BauStoffe.Add(new Ressource("Holz", 100)); break;
                    default: throw new Exception("Building doesnt Exist in newBuildintTypes"); 
                }
                
            }
            
        }

    }
}
