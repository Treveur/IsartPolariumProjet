using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace IsartPolarium
{
	public class Level7 : AScene
	{
		///<summary>
		///Structure du niveau represente sous forme de tableau
		/// 0 : Case grise
		/// 1 : Face/Case noire
		/// 2 : Pile / Case blanche
		/// 3 : Speciale Face
		/// 4 :	Special Pile
		///</summary>
		int[,] levelstructure = 
		{
			{0, 0, 0, 0, 0, 0, 0, 0},
			{0, 2, 1, 3, 1, 2, 2, 0},
			{0, 1, 2, 2, 2, 1, 2, 0},
			{0, 2, 2, 1, 2, 2, 2, 0},
			{0, 4, 2, 1, 2, 1, 2, 0},
			{0, 2, 1, 2, 1, 2, 3, 0},
			{0, 3, 2, 1, 2, 1, 1, 0},
			{0, 0, 0, 0, 0, 0, 0, 0}
		};

		public Level7 (SceneManager _SM) : base(_SM)
		{
		}

		/// <summary>
		/// We initialize our scene
		/// </summary>
		public override void Initialize()
		{
			base.Initialize ();
		}

		/// <summary>
		/// We load the content of our scene
		/// </summary>
		public override void LoadContent()
		{
			base.LoadContent ();
		}

		/// <summary>
		/// We Update our scene.
		/// If it's the first time we enter in this function, we add our player and a grid.
		/// </summary>
		/// <param name="gameTime">Game time.</param>
		public override void Update (GameTime gameTime)
		{
			if (GetEntitiesNbr () == 0) {	
				//Ajout de l'entité player sur la scene
				//AddEntity (new Player (this));
				Player pl = new Player (this);
				AddEntity (pl);

				//Ajout de l'entité grille sur la scene
				GridCase gc = new GridCase (this, 8, 8, levelstructure);
				AddEntity (gc);

			}
			base.Update (gameTime);
		}

		///			 <summary>
		/// We draw all the entity of our scene
		/// </summary>
		/// <param name="gameTime">Game time.</param>
		public override void Draw(GameTime gameTime)
		{
			base.Draw (gameTime);
		}
	}
}

