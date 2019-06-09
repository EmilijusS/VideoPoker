using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoPoker
{
    public class Scorer
    {
        private List<Card> hand;

        public Scorer(List<Card> hand)
        {
            this.hand = hand;
        }

        public CardCombinationType GetCombination()
        {
            throw new NotImplementedException();
        }
    }
}
