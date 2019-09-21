# UI-
UI框架
框架通过GameBootStrap进入游戏，同时初始化游戏内的一些单例Manager，最后指定一个GameState进入游戏
UIManager:
通过字典存储加载过得UIPanel,在Show方法中通过C# Assembly.GetExecutingAssembly().GetType("PanelName")来获取当前界面的控制组件类型
GameStateManager:
同理，只是切换特殊的游戏状态需调用SceneManager切换场景
