using _Project.Scripts.Infrastructure;

public class StatsDefaultModel
{
    public readonly ReactiveProperty<int> Str = new();
    public readonly ReactiveProperty<int> Dex = new();
    public readonly ReactiveProperty<int> Int = new();

    private int _skillPointsAvailableAvailable;

    public int SkillPointsAvailable
    {
        get => _skillPointsAvailableAvailable;
        set => _skillPointsAvailableAvailable = value;
    }

    public StatsDefaultModel(int str, int dex, int intel, int skillPointsAvailable)
    {
        Str.Value = str;
        Dex.Value = dex;
        Int.Value = intel;
        SkillPointsAvailable = skillPointsAvailable;
    }
}

