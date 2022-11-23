using Entities.Concrete;

namespace SessionYapısı.Services
{
    public interface ICartSessionService
    {
        Cart GetCart();
        void SetCart(Cart cart);
    }
}
