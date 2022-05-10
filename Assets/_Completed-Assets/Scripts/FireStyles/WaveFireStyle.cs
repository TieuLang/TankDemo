namespace Complete
{
    public partial class WaveFireStyle : FireStyleComp
    {
        public float currentInterval=0.0f;
        public override void OnDoneTrigger()
        {
            base.OnDoneTrigger();
            currentInterval = 0.0f;
        }
    }
}