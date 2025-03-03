using UnityEngine;
using UnityEngine.UI;
using static allControl;

public class ItemCollector : MonoBehaviour
{
    int cherries = GameManager.Instance.score;

    [SerializeField] private Text cherriesText;
    [SerializeField] private AudioSource collectSoundEffect;
    //Text 是 Unity UI（User Interface）系统中的一个组件类型，位于 UnityEngine.UI 命名空间中
    //cherriesText是变量名，用于存储 UI 文字组件的引用，稍后会用它来更新屏幕上的文本内容

    private void Start()
    {
        cherriesText.text = "Cherries:" + cherries;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    //这是 Unity 里的 物理触发器 方法（事件回调），用于 检测 2D 物体进入触发区域 时执行特定的代码逻辑。
    //collision 是一个 参数，它是 Collider2D 类型，表示 进入触发区域的物体
    //你可以用 collision.gameObject 来获取进入触发器的游戏对象
    {
        if (collision.gameObject.CompareTag("Cherry"))
        {
            collectSoundEffect.Play();
            Destroy(collision.gameObject);
            cherries++;
            cherriesText.text = "Cherries:" + cherries;

            GameManager.Instance.score = cherries;
        }
    }
}
