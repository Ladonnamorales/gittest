using UnityEngine;
using UnityEngine.UI;
using static allControl;

public class ItemCollector : MonoBehaviour
{
    int cherries = GameManager.Instance.score;

    [SerializeField] private Text cherriesText;
    [SerializeField] private AudioSource collectSoundEffect;
    //Text �� Unity UI��User Interface��ϵͳ�е�һ��������ͣ�λ�� UnityEngine.UI �����ռ���
    //cherriesText�Ǳ����������ڴ洢 UI ������������ã��Ժ��������������Ļ�ϵ��ı�����

    private void Start()
    {
        cherriesText.text = "Cherries:" + cherries;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    //���� Unity ��� �������� �������¼��ص��������� ��� 2D ������봥������ ʱִ���ض��Ĵ����߼���
    //collision ��һ�� ���������� Collider2D ���ͣ���ʾ ���봥�����������
    //������� collision.gameObject ����ȡ���봥��������Ϸ����
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
