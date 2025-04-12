namespace FSM.Decisions
{
    public class DecisionWaitMinigame : FSMDecision
    {
        public override bool Decide(FSMContext context)
        {
            // MiniGameManager._miniGameManager.StopMainGame();
            return true;
        }
    }
}