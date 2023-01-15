using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Domain
{
    public interface IGameManager
    {
        bool IsGameEnded { get; }
        void StartGame();
        void EndGame();
    }
}
