using System.Linq;
using System.Threading.Tasks;
using Alsein.Extensions;

namespace Cynthia.Card
{
    [CardEffectId("70105")]//阿道伯图斯·卡尔克斯坦 AdalbertusKalkstein
    public class AdalbertusKalkstein : CardEffect
    {//使一个单位的战力等同于自身战力。
        public AdalbertusKalkstein(GameCard card) : base(card) { }
        public override async Task<int> CardPlayEffect(bool isSpying, bool isReveal)
        {
            
            var selectList = await Game.GetSelectPlaceCards(Card, selectMode: SelectModeType.AllRow);
            if (!selectList.TrySingle(out var target))
            {
                return 0;
            }
            if(target.CardPoint()>Card.CardPoint())
            {
                await target.Effect.Damage(target.CardPoint()-Card.CardPoint(), Card, BulletType.RedLight, true);//造成穿透伤害
            }
            else if(target.CardPoint()<Card.CardPoint())
            {
                await target.Effect.Boost(Card.CardPoint()-target.CardPoint(), Card);//增益
            }
            return 0;
        }
    }
}