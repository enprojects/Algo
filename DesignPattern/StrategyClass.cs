using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{
    public enum StratagyName
    {
        A,
        B
    }

    public interface IStrategy
    {
        void Execute();
    }


    public class StrategyA : IStrategy
    {
        public void Execute()
        {
            throw new NotImplementedException();
        }
    }

    public class StrategyB : IStrategy
    {
        public void Execute()
        {
            throw new NotImplementedException();
        }
    }
    public class StrategyC : IStrategy
    {
        public void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
