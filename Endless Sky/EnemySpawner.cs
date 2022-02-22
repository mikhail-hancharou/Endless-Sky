using System;
using System.Collections.Generic;
using System.Text;

namespace Endless_Sky
{
    public class EnemySpawner
    {
        const int maxAmount = 5;
        public int currentAmount = 0;
        public List<Player> enemies = new List<Player>();
        public EnemySpawner() { }
    }
}
