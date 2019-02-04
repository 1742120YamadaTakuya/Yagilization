using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;

    private Grass grass;


    // Grass getGrass() - このセルの草の状況をGrass構造体で返す (Grass構造体はstruct_grassで定義)
    public Grass getGrass()
    {
        return grass;
    }


    // void updateGrass(Color color) - このセルの草の状況を1ターン分更新する (引数のcolorはヤギの色) ※このセルにヤギがいた(いる)場合のみ呼び出す
    public void growGrass(Color color)
    {
        if (grass.isGrow){
            if (grass.color != color){
                setGrass(false, Color.black);
            }
        }else{
            setGrass(true, color);
        }
    }


    // void setGrass(bool isGrow, Color color) - このセルの草の状況を設定する
    public void setGrass(bool isGrow, Color color)
    {
        grass.isGrow = isGrow;
        grass.color = color;
        setEnable(isGrow);
    }


    // void setEnable(bool isDraw) - このセルの草の表示/非表示を設定する
    private void setEnable(bool isDraw)
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = isDraw;
    }


    // void split (int n) - 自身をroot(n)等分する
    public void split (int n)
    {
        GameObject obj;

        Vector3 parentPosition = gameObject.transform.localPosition;
        Vector3 parentScale = gameObject.transform.localScale;

        Vector3 childPosition;
        Vector3 childScale = new Vector3(parentScale.x * (1.0f / n), parentScale.y * (1.0f / n), parentScale.z);

        float width = GetComponent<SpriteRenderer>().bounds.size.x;
        float height = GetComponent<SpriteRenderer>().bounds.size.y;

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                childPosition = new Vector3(parentPosition.x + width * ((1 - n) + 2 * j) / (2.0f * n), parentPosition.y + height * ((1 - n) + 2 * i) / (2.0f * n), parentPosition.z);

                obj = Instantiate(prefab, childPosition, Quaternion.identity);
                obj.transform.localScale = childScale;
                obj.GetComponent<Cell>().setGrass(false, Color.black);
            }
        }

        Destroy(gameObject);

    }

}
