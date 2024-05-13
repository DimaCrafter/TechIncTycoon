public class ComputationUnitAssembleMenu: MenuBehaviour<ModulePlace> {
    public void Place () {
        parent.Type = ModulePlaceType.Eniac;
        parent.Reset();
        //Scenario.Fire(Scenario.Trigger.ModuleInstall);
    }
}
