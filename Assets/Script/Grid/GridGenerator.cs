using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    // グリッドの行列
    [SerializeField] public int _row;
    [SerializeField] public int _col;
    // 1マスの大きさ
    [SerializeField] float _cellSize;
    // グリッドの通し番号
    public int[,] _gridIndex;
    GameObject[,] _grid;
    // グリッドのPrefabオブジェクト
    [SerializeField] GameObject _gridTilePrefab;

    void Start()
    {
        _gridIndex = new int[_row, _col];
        _grid = new GameObject[_row, _col];
        // グリッドの中心を(0,0,0)にするためのオフセット
        float offsetX = (_row - 1) * _cellSize / 2f;
        float offsetZ = (_col - 1) * _cellSize / 2f;
        for (int r = 0; r < _row; r++)
        {
            for (int c = 0; c < _col; c++)
            {
                // グリッドのポジション
                Vector3 pos = new Vector3(r * _cellSize - offsetX, 0f, c * _cellSize - offsetZ);
                // グリッドの生成
                GridInstantiate(r,c,pos);
                _gridIndex[r, c] = r * _col + c;
            }
        }
    }
    // グリッドの生成
    void GridInstantiate(int row,int col,Vector3 pos)
    {
        _grid[row, col] = Instantiate(_gridTilePrefab, pos, Quaternion.identity, transform);
        Debug.Log($"{_grid[row, col]} = {row} : {col}");
    }
}
