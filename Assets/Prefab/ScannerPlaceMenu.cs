public class ScannerPlaceMenu: MenuBehaviour<ScannerPlace> {
    public void Place () {
        parent.Used = true;
        parent.Reset();
        Scenario.Fire(Scenario.Trigger.ScannerInstall);
    }
}
