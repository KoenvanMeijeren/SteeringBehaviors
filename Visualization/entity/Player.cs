using Src.entity;
using Src.util;
using Src.world;
using SteeringCS.behavior;
using SteeringCS.util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteeringCS.entity
{
    public class Player : MovingEntity, IRender
    {
        public Player(Vector position, IWorld world) : base(position, world)
        {
            Velocity = new Vector(0, 0);
        }

        public void Render(Graphics graphic)
        {

        }
    }
}
