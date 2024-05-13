using System;

[Serializable]
public class GameState {
    public uint scenarioStep = 0;
    public ModulePlaceType[] modulePlaceTypes = new ModulePlaceType[] {
        ModulePlaceType.None,
        ModulePlaceType.None,
        ModulePlaceType.Eniac,
        ModulePlaceType.Eniac,
        ModulePlaceType.None
    };

    public bool[] scannerPlace = new bool[] {
        false,
        false,
        false
    };
}
