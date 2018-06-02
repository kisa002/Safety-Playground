using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class ServerManager : MonoBehaviour
{
    [SerializeField]
    GameObject registerResult;

    [SerializeField]
    Text textName, textTitle, textContent, textId, textPw;

    //1 : 회원가입 성공
    //10 : 사용자이름 3글자 ~ 7글자
    //11 : 아이디 4글자 ~ 10글자
    //12 : 비밀번호 6글자 ~ 12글자
    //20 : 중복 이름

    public void Register()
    {
        if (textName.text.Length >= 3 && textName.text.Length <= 7)
            if (textId.text.Length >= 4 && textId.text.Length <= 10)
                if (textPw.text.Length >= 6 && textPw.text.Length <= 12)
                    StartCoroutine(CorRegister());
                else
                    ShowRegisterResult(12);
            else
                ShowRegisterResult(11);
        else
            ShowRegisterResult(10);
    }

    public void ShowRegisterResult(int type)
    {
        registerResult.SetActive(true);
        textTitle.text = (type == 1) ? "회원가입 성공" : "회원가입 실패";
        
        switch (type)
        {
            case 1:
                textContent.text = "회원가입이 완료되었습니다";
                break;

            case 10:
                textContent.text = "이름은 3~7 글자 사이입니다";
                break;

            case 11:
                textContent.text = "아이디는 4~10 글자 사이입니다";
                break;

            case 12:
                textContent.text = "비밀번호는 6~12 글자 사이입니다";
                break;

            case 20:
                textContent.text = "이미 존재하는 이름입니다";
                break;
        }
    }

    public void CloseRegisterResult()
    {
        registerResult.SetActive(false);
    }

    IEnumerator CorRegister()
    {
        WWWForm form = new WWWForm();

        form.AddField("name", textName.text);
        form.AddField("amount", 50000);

        WWW www = new WWW("http://safetyplay.dothome.co.kr/create/user", form);

        yield return www;

        if (www.text.IndexOf("true") != -1)
            ShowRegisterResult(1);
        else
            ShowRegisterResult(20);
    }
}