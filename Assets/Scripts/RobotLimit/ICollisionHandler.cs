using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.RobotLimit
{
    public interface ICollisionHandler
    {
        void HandleCollision(bool isStay, string object1, string object2);
    }

}
