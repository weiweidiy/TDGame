using JFramework;
using JFramework.Game;


namespace Tiktok
{
    public class CurrentGuideStepModel : BaseModel<string>
    {
        public class EventUpdate : Event { }
        public CurrentGuideStepModel(EventManager eventManager) : base(eventManager)
        {
        }

        public void UpdateCurrentGuideStep(string guideStep)
        {
            data = guideStep;
            SendEvent<EventUpdate>(guideStep);
        }
    }

}
