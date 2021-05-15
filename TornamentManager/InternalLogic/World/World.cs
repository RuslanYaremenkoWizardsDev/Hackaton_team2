using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TornamentManager
{
    public class World:IWorld

    {
        static World _instance;
        private World()
        {
        }

        public static IWorld WorldInstance
        {
            get
            {
                if (_instance==null)
                { 
                    _instance = new World(); 
                }
                return _instance;
            }
        }
    }

}
