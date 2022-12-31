using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    public Sprite[] TileSprites;
    public Sprite[] BackingTileSprites;

    public GameObject[] MyBackingTiles;
    public GameObject[] MyTiles;

    void Start()
    {
        SetMyBackingTileSprite();
        SetMyTileSprites();
    }

    private Sprite GetRandomTileSprite()
    {
        return TileSprites[Random.Range(0, TileSprites.Length)];
    }

    private Sprite GetRandomBackingTileSprite()
    {
        return BackingTileSprites[Random.Range(0, BackingTileSprites.Length)];
    }

    private void SetMyBackingTileSprite()
    {
        foreach (var backingTile in MyBackingTiles)
        {
            var SpriteRenderer = backingTile.GetComponent<SpriteRenderer>();
            SpriteRenderer.sprite = GetRandomBackingTileSprite();
        }
    }

    private void SetMyTileSprites()
    {
        foreach (var tile in MyTiles)
        {
            var SpriteRenderer = tile.GetComponent<SpriteRenderer>();
            SpriteRenderer.sprite = GetRandomTileSprite();
        }
    }
}
