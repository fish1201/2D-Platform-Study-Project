# 2D Platform
1. sunny land 2D横版闯关游戏 跟着B站up主M_studio学着做了一遍  

2. robbie 进阶的2d平台游戏 同样也是学习了M_studio的视频教程，但后面有点摆烂了，UI和转场效果都没做QAQ。  

**相比上一个项目 多了**：  

 1> 人物动作：长按跳跃跳的更高、下蹲跳跃跳的最高，新增悬挂墙壁。  
 
 2> 状态检测：触碰地面的检测和头顶墙的检测从层级碰撞和Physics2d的球形检测变成射线检测RayCast2D  
 
 3> 摄像机透视：前后景透视效果从上一个项背景跟随人物移动一小段的方法变成摄像机透视。  
 
 4> tilemap: 学会使用2D tilemap Extra插件中的gameobject Brush，可以在tilemap中直接绘制物体。  
 
 5> 代码的管理：不同方面的代码分开放，例如PlayerMovement控制人物移动,PlayerHealth控制人物死亡, AudioManager中放置所有音乐效果的代码，GameManager控制场景的转换，Collection代码中控制左上角orbtext的变化和orb数量的增加。  
 
 6> 单例：  
 
 static ClassName instance;  Awake(){instance = this;}    
 若要让该控件在场景转换中不用重复生成，永远不会消失，可以使用DontDestroy方法。  
    
 
