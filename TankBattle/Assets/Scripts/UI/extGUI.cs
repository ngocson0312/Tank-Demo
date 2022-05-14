using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class extGUI : MonoBehaviour
{
    public Text TextGuide;
    
    private void Start()
    {
        StartCoroutine(textScore());
    }

    IEnumerator textScore()
    {
        
        TextGuide.text = "- Chào mừng bạn đến với game Tank Battle .Có tất cả là ba màn chơi.";
        yield return new WaitForSeconds(3f);
        TextGuide.text = "- Để qua được màn chơi, bạn phải tiêu diệt hết tất cả tank địch.";
        yield return new WaitForSeconds(3f);
        TextGuide.text = "- Trong quá trình chơi sẽ có các vật phẩm được sinh ra, hãy cố gắng ăn nó.";
        yield return new WaitForSeconds(3f);
        TextGuide.text = "- Bây giờ hãy sử dụng sự khéo léo của bạn để chinh phục thôi nào.";
        yield return new WaitForSeconds(3f);
        TextGuide.text = "Let's Go";
        yield return new WaitForSeconds(1f);
        GameManager.instance.textGUIFalse();
    }
}
