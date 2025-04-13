namespace FSM.Decisions
{
    public class ActionWaitMinigame : FSMDecision
    {
        public override bool Decide(FSMContext context)
        {
            // MiniGameManager._miniGameManager.StopMainGame();
            return true;
        }
    }
}