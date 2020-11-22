using UnityEngine;
using UnityEngine.Tilemaps;
using TMPro;
using System.Security.Cryptography;
using System.Text;


public class GameManager : MonoBehaviour
{
    public Grid grid;
    public Tilemap map;
    public Tile[] tiles;

    int width = 16;
    int height = 9;

    float cameraSpeed = 10f;
    public int randomKey;
    public int perlinScale;

    public TMP_Text xCoord, yCoord;
    public Transform cam;

    // Start is called before the first frame update
    void Start()
    {
        GenerateStars();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Horizontal") != 0)
        {
            cam.position = Vector3.Lerp(cam.position, cam.position + Vector3.right * Input.GetAxis("Horizontal"),
                cameraSpeed * Time.deltaTime);

            map.ClearAllTiles();
            GenerateStars();
        }

        if (Input.GetAxis("Vertical") != 0)
        {
            cam.position = Vector3.Lerp(cam.position, cam.position + Vector3.up * Input.GetAxis("Vertical"),
                cameraSpeed * Time.deltaTime);

            map.ClearAllTiles();
            GenerateStars();
        }
    }

    public void GenerateStars()
    {
        Vector3Int camPosOneTilemap = map.WorldToCell(Camera.main.transform.position);
        xCoord.text = camPosOneTilemap.x.ToString();
        yCoord.text = camPosOneTilemap.y.ToString();

        for(int x = camPosOneTilemap.x - width; x < camPosOneTilemap.x + width; x++)
        {
            for(int y = camPosOneTilemap.y - height; y < camPosOneTilemap.y + height; y++)
            {
                Vector3Int tilePos = new Vector3Int(x, y, 0);

                //Bitwise operations
                //int seed = y + randomKey << 16 | x + randomKey;
                //Random.InitState(seed);

                //Cantor Pairinr
                int seed = (int)(0.5f * (x + y) * (x + y + 1) + y);
                Random.InitState(seed);

                //SHA256
                //SHA256 sha = SHA256.Create();
                //byte[] byteResult = sha.ComputeHash(Encoding.ASCII.GetBytes(x.ToString() + y.ToString()));
                //string strResult = System.BitConverter.ToString(byteResult);
                //strResult = "0" + strResult;
                //strResult = strResult.Replace("-", "");
                //System.Numerics.BigInteger intResult = System.Numerics.BigInteger.Parse(
                //    strResult, System.Globalization.NumberStyles.AllowHexSpecifier);

                //if (intResult % 5 == 0)
                //{
                //    map.SetTile(tilePos, tiles[(int)(intResult % 36) / 6]);
                //}


                //Perlin Noise
                //float xPos = (float)x / width * perlinScale;
                //float yPos = (float)y / height * perlinScale;
                //float perlin = Mathf.PerlinNoise(xPos, yPos);
                //Random.InitState(Mathf.RoundToInt(perlin * 10000000));

                if (Random.Range(0, 10) < 3)
                {
                    map.SetTile(tilePos, tiles[Random.Range(0, tiles.Length)]);
                }

            }
        }
    }
}
