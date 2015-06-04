using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace IsartPolarium
{
	public class Sprite
	{
		public string textureLink {
			get {return _textureLink;}
			set {
				if (_textureLink != value)
					loaded = false;
				_textureLink = value;
				}
		}
		private string _textureLink;

		public bool loaded { get; private set; }

		public Texture2D texture2D;
		public Vector2 position;
		public List<Rectangle> _LSpriteSources;
		public Color color;
		public float rotation;
		public Vector2 origin;
		public float scale;
		public SpriteEffects effects;
		public float depth;

		float widthNbr;
		float heightNbr;

		public Vector2 frameSizeWoScale;
		public int currentFrame;
		int _maxFrame;
		int _frameRefreshTime;
		int _totalRefreshTime;

		public Sprite (string tLink, int wnbr, int hnbr, int maxFrame, int frt)
		{
			textureLink = tLink;
			loaded = false;
			widthNbr = wnbr;
			heightNbr = hnbr;
			_maxFrame = maxFrame;
			_LSpriteSources = new List<Rectangle> ();
			color = Color.White;
			rotation = 0;
			scale = 1f;
			effects = SpriteEffects.None;
			depth = 0;

			currentFrame = 0;
			_frameRefreshTime = frt;
			_totalRefreshTime = frt;
		}

		public Sprite (string tLink) : this(tLink, 1, 1, 1, 0)
		{
		}

		public void CalculateSprite()
		{
			int xSize = (int)(texture2D.Width / widthNbr);
			int ySize = (int)(texture2D.Height / heightNbr);
			for (int j = 0; j < heightNbr; j++)
			{
				for (int i = 0; i < widthNbr; i++)
					_LSpriteSources.Add (new Rectangle(i * xSize, j * ySize, xSize, ySize));
			}
			origin = new Vector2 (xSize / 2, ySize / 2);
			frameSizeWoScale = new Vector2 (xSize, ySize);
			loaded = true;
		}

		public void Update(GameTime gameTime)
		{
			_frameRefreshTime -= gameTime.ElapsedGameTime.Milliseconds;
			if (_frameRefreshTime <= 0)
			{
				_frameRefreshTime = _totalRefreshTime;
				currentFrame++;
				if (currentFrame >= _maxFrame)
					currentFrame = 0;
			}
		}

		public void Draw(GameTime gameTime)
		{			
		}
	}
}

