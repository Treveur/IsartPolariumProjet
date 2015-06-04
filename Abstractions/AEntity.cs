using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace IsartPolarium
{
	public abstract class AEntity
	{
		/// <summary>
		/// The name of the entity. Not mandetory
		/// </summary>
		public string name;

		protected AScene _scene;
		public Sprite sprite;

		public Rectangle hitBox { get; private set; }

		/// <summary>
		/// Gets or sets the position.
		/// </summary>
		/// <value>The position.</value>
		public virtual Vector2 Position {
			get { return _position; }
			set 
			{
				_position = value;
				if (sprite != null)
					sprite.position = _position;
			}
		}
		protected Vector2 _position;

		/// <summary>
		/// Gets the size of the psirte.
		/// </summary>
		public Vector2 Size {
			get {
				if (sprite != null)
					return (sprite.frameSizeWoScale * sprite.scale);
				return Vector2.Zero;
			}
			private set { }
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="IsartPolarium.AEntity"/> class.
		/// </summary>
		/// <param name="scene">Scene.</param>
		protected AEntity (AScene scene)
		{
			_scene = scene;
		}

		/// <summary>
		/// Initialize your entity.
		/// </summary>
		public virtual void Initialize()
		{
			name = "entity";
		}

		/// <summary>
		/// Use this fonction to loads the content.
		/// </summary>
		public virtual void LoadContent ()
		{
		}

		/// <summary>
		/// Update at the specified gameTime.
		/// </summary>
		/// <param name="gameTime">Game time.</param>
		public virtual void Update (GameTime gameTime)
		{
			if (sprite != null)
			{
				sprite.Update (gameTime);
				hitBox = new Rectangle((int)(Position.X - (sprite.origin.X * sprite.scale)),
					(int)(Position.Y - (sprite.origin.Y * sprite.scale)),
					(int)Size.X, (int)Size.Y);
			}
		}

		/// <summary>
		/// Draw the sprite of the entity.
		/// </summary>
		/// <param name="gameTime">Game time.</param>
		public virtual void Draw (GameTime gameTime)
		{
			if (sprite != null)
			{
				_scene.sceneManager.spriteBatch.Draw (sprite.texture2D, sprite.position, sprite._LSpriteSources [sprite.currentFrame], sprite.color,
					sprite.rotation, sprite.origin, sprite.scale, sprite.effects, sprite.depth);
			}
		}

		/// <summary>
		/// Use these to attach a sprite to the entity
		/// </summary>
		/// <param name="s">Allready created sprite</param>
		public void LinkSprite(Sprite s)
		{
			sprite = s;
			LoadSprite ();
		}

		/// <summary>
		/// Use these to attach a sprite to the entity
		/// </summary>
		/// <param name="tlink">Name of the sprite.</param>
		public void LinkSprite(string tlink)
		{
			sprite = new Sprite (tlink);
			LoadSprite ();
		}

		/// <summary>
		/// Use these to attach a sprite to the entity
		/// </summary>
		/// <param name="tlink">Name of the sprite.</param>
		/// <param name="wnbr">Widht size.</param>
		/// <param name="hnbr">Heigth size.</param>
		/// <param name="maxFrame">Number of frame to make animation.</param>
		/// <param name="frt">Frame Rate (number of image per seconde).</param>
		public void LinkSprite(string tlink, int wnbr, int hnbr, int maxFrame, int frt)
		{
			sprite = new Sprite (tlink, wnbr, hnbr, maxFrame, frt);
			LoadSprite ();
		}

		private void LoadSprite()
		{
			if (sprite.loaded == false) {
				sprite.texture2D = _scene.sceneManager.content.Load<Texture2D> (sprite.textureLink);
				sprite.position = _position;
				sprite.CalculateSprite ();
			}
		}
	}
}
