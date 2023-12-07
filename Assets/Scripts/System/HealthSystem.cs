public class HealthSystem
{
    public int Health
    {
        get => _health;
    }

    private int _health;

    public HealthSystem(int health)
    {
        _health = health;
    }

    public void Damage(int damageAmount)
    {
        _health -= damageAmount;
        if (_health < 0) _health = 0;
    }
}
