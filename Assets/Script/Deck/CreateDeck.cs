using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateDeck : MonoBehaviour
{
    // デッキ本体
    [SerializeField] public List<CardData> _cardList;
    [SerializeField] public List<CardData> _playDeck;

    // カードのデザインのImagePrefab
    [SerializeField] Image _image;
    // 親オブジェクトの座標
    [SerializeField] Transform Transform;
    void Start()
    {
        _cardList = new List<CardData>(); 
    }

    // デッキにカードを登録する
    public void AddCard(CardData cardData)
    {
        if (_cardList.Count < 40)
        {
            _cardList.Add(cardData);

            // 追加したカードを表示するための処理
            _image.sprite = cardData.Sprite;
            Image newImage = Instantiate(_image);
            newImage.transform.SetParent(Transform); // Transformの子オブジェクトに
        }
        else Debug.Log($"既定の枚数に達しています。"); 
    }
    // デッキの登録
    public void AddDeck()
    {
        _playDeck = new List<CardData>();
        _playDeck = _cardList;
        Debug.Log("デッキが登録されました");
    }
}
