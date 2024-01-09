using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;

public class generate_quiz : MonoBehaviour
{
    public ToggleGroup toggleGroup;
    public TMP_Text output, question;
    public Toggle toggle_1, toggle_2, toggle_3, toggle_4;
    private bool is_open = false;
    private string[] questions = new string[]
    {
        "Что такое перфокарта в контексте компьютеров?",
        "Какой изобретатель связан с созданием перфокарт в 1890 году?",
        "Каков был основной метод хранения данных на перфокартах?",
        "Когда был представлен ENIAC, первый электронный компьютер в мире?",
        "Кто является основным создателем ENIAC?",
        "Какой принцип лежит в основе работы ENIAC?",
        "Какой был основной целью создания ENIAC?",
        "Какие электронные компоненты использовались в ENIAC?",
        "Какова была вычислительная мощность ENIAC?",
        "Какие размеры имел ENIAC?"
    };
    private string[] right_ans = new string[]
    {
        "Перфокарта — это перфорированная карта с информацией для программирования",
        "Герман Холлерит",
        "Информация кодировалась отверстиями в карте, представляя различные команды и данные.",
        "1946 год",
        "Джон Преспер Эккерт и Джон Уильям Мокли",
        "Электронные лампы для обработки и хранения данных.",
        "Решение сложных научных и инженерных задач, включая боевые расчёты во время Второй мировой войны.",
        "Вакуумные лампы",
        "Около 5000 операций в секунду",
        "Около 30х50 футов"
    };
    private string[] wrong_ans_1 = new string[]
    {
        "Перфокарта — устройство для вывода цветных изображений на мониторе.",
        "Чарльз Бэббидж",
        "Данные записывались с использованием магнитных полос на поверхности карты.",
        "1960 год",
        "Алан Тьюринг",
        "Механические рычаги для вычислений.",
        "Обработка текстов и документов.",
        "Транзисторы",
        "1 миллион операций в секунду",
        "10х10 метров"
    };
    private string[] wrong_ans_2 = new string[]
    {
        "Перфокарта — вид магнитной ленты для хранения данных.",
        "Алан Тьюринг",
        "Каждая карта имела нанесенные баркоды для хранения информации.",
        "1955 год",
        "Чарльз Бэббидж",
        "Оптические диски для хранения информации.",
        "Развлечения и игры.",
        "Кремниевые чипы",
        "10 000 операций в секунду",
        "5х5 футов"
    };
    private string[] wrong_ans_3 = new string[]
    {
        "Перфокарта — программа для защиты компьютера от вирусов.",
        "Стивен Хокинг",
        "Информация передавалась посредством световых сигналов между картами.",
        "1935 год",
        "Стив Джобс",
        "Электростатический метод обработки данных.",
        "Создание многозадачной операционной системы.",
        "Резисторы",
        "100 операций в секунду",
        "100х100 миллиметров"
    };
    public static int rand_num;
    public void Generate_Question()
    {
        rand_num = Random.Range(0, questions.Length);
        question.text = questions[rand_num];
        string[] ans_pool = new string[4];

        ans_pool[0] = right_ans[rand_num];
        ans_pool[1] = wrong_ans_1[rand_num];
        ans_pool[2] = wrong_ans_2[rand_num];
        ans_pool[3] = wrong_ans_3[rand_num];

        string tmp, tmp1, tmp2, tmp3;
        tmp = ans_pool[Random.Range(0, 4)];
        toggle_1.GetComponentInChildren<Text>().text = tmp;
        tmp1 = tmp;
        while (tmp == tmp1)
            tmp = ans_pool[Random.Range(0, 4)];
        toggle_2.GetComponentInChildren<Text>().text = tmp;
        tmp2 = tmp;
        while (tmp == tmp1 || tmp2 == tmp)
            tmp = ans_pool[Random.Range(0, 4)];
        toggle_3.GetComponentInChildren<Text>().text = tmp;
        tmp3 = tmp;
        while (tmp == tmp1 || tmp2 == tmp || tmp3 == tmp)
            tmp = ans_pool[Random.Range(0, 4)];
        toggle_4.GetComponentInChildren<Text>().text = tmp;
    }
    public void Check()
    {
        Toggle toggle = toggleGroup.ActiveToggles().FirstOrDefault();
        if (toggle.GetComponentInChildren<Text>().text == right_ans[rand_num])
            output.text = "Ответ верный";
        else
            output.text = "Ответ не верный";
    }
}
