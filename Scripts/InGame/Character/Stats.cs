public class Stats : PoolObject, IStats {
    private float _health;
    private float _energyShield;
    private float _defence;
    private float _structure;

    public float energyShield {
        get { return _energyShield; }
        set { _energyShield = value; }
    }

    public float health {
        get { return _health; }
        set { _health = value; }
    }

    public float defence {
        get { return _defence; }
        set { _defence = value; }
    }

    public float structure {
        get { return _structure; }
        set { _structure = value; }
    }
}
