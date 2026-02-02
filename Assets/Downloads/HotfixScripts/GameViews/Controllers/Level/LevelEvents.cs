using JFramework;

namespace Tiktok
{
    //业务逻辑事件

    //public class EventLevelNodeUpdate : Event { } //List<string>
    //public class EventEnterLevel : Event { } //string
    public class EventExitLevel : Event { }
    public class EventSwitchLevel : Event { } //string

    public class EventRequestCombat : Event { } //string
    //public class EventStartCombat : Event { } //string
    public class EventExitCombat : Event { } //string

    public class EventDrawSamurai : Event { } //DrawDTO
}
