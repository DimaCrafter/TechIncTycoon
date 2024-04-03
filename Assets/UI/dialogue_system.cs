using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class DialogSystem : MonoBehaviour
{
	public int textIndex = 0;
	private string[] Dialogue_text  =  new string[]
		{
		"Маски подсети помогают рабочим станциям, серверам и маршрутизаторам определить, находится ли устройство, для которого предназначен передаваемый в сеть пакет, в их собственной (локальной сети) или в другой сети (с которой устройство не имеет непосредственного соединения). Для этого каждое устройство перед отправкой пакета в сеть через определенный интерфейс определяет, совпадает ли адрес подсети, в которой он находится, с адресом подсети, в которую адресован пакет. Процедура проста",
		"Когда поднимается одна пылинка, в ней содержится вся земля, когда распускается один цветок, раскрывается целый мир",
		};
	private string[] lines;
	private int maxLine = 200;

	private void ParseText()
    {
		string[] tmp;
		string[] tmp_lines = new string[20];
		for (int j = 0; j < 20; j++)
			tmp_lines[j] = "";
		tmp = Dialogue_text[textIndex].Split(' ');
		int i = 0;
		foreach(string s in tmp)
        {

			if(tmp_lines[i].Length + s.Length + 1 <= maxLine)
            {
				tmp_lines[i] += s;
				tmp_lines[i] += " ";
            }
			else
            {
				i++;
				tmp_lines[i] += s;
				tmp_lines[i] += " ";
			}
        }
		lines = new string[i+1];
		for(int j = 0; j <= i; j++)
        {
			lines[j] = tmp_lines[j];
        }
    }

	public float speedText;
	public Text dialogText;

	public int index;
	void Start()
	{
		ParseText();
		index = 0;
		StartDialog();
	}
	void StartDialog()
	{
		dialogText.text = string.Empty;
		StartCoroutine(TypeLine());
	}
	IEnumerator TypeLine()
	{
		foreach (char c in lines[index].ToCharArray())
		{
			dialogText.text += c;
			yield return new WaitForSeconds(speedText);
		}
	}
	public void scipTextClick()
	{
		if (dialogText.text == lines[index])
		{
			NextLines();
		}
		else
		{
			StopAllCoroutines();
			dialogText.text = lines[index];
		}
	}
	private void NextLines()
	{
		if (index < lines.Length - 1)
		{
			index++;
			dialogText.text = string.Empty;
			StartDialog();
		}
		else
		{
			gameObject.SetActive(false);
		}
	}
}