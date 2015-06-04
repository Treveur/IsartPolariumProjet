using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace IsartPolarium
{
	public class LevelButtons : AScene
	{
		Button ULvl1;
		Button DLvl1;

		Button ULvl2;
		Button DLvl2;


		public LevelButtons (SceneManager _SM) : base(_SM)
		{
		}

		/// <summary>
		/// We initialize our scene
		/// </summary>
		public override void Initialize()
		{
			ULvl1 = new Button (this, "UButton");
			ULvl1.Position = new Vector2 (40, sceneManager.graphics.PreferredBackBufferHeight - 100);
			ULvl2 = new Button (this, "UButton");
			ULvl2.Position = new Vector2 (90, sceneManager.graphics.PreferredBackBufferHeight - 100);

			DLvl1 = new Button (this, "DButton");
			DLvl1.Position = new Vector2 (40, sceneManager.graphics.PreferredBackBufferHeight - 50);
			DLvl2 = new Button (this, "DButton");
			DLvl2.Position = new Vector2 (90, sceneManager.graphics.PreferredBackBufferHeight - 50);

			base.Initialize ();
		}

		/// <summary>
		/// We load the content of our scene
		/// </summary>
		public override void LoadContent()
		{
			AddEntity (ULvl1);
			AddEntity (ULvl2);
			AddEntity (DLvl1);
			AddEntity (DLvl2);

			base.LoadContent ();
		}

		/// <summary>
		/// We Update our scene.
		/// If it's the first time we enter in this function, we add our player and a grid.
		/// </summary>
		/// <param name="gameTime">Game time.</param>
		public override void Update (GameTime gameTime)
		{
			if (ULvl1.changed || DLvl1.changed) {
				ChangeSceneState (ULvl1._state, DLvl1._state, sceneManager.GetScene(1));
				ULvl1.changed = false;
				DLvl1.changed = false;
			}

			if (ULvl2.changed || DLvl2.changed) {
				sceneManager.GetScene(0).sceneState = ChangeSceneState (ULvl2._state, DLvl2._state);
				ULvl2.changed = false;
				DLvl2.changed = false;
			}

			base.Update (gameTime);
		}

		SceneState ChangeSceneState(bool upd, bool dra)
		{
			if (upd && dra)
				return SceneState.UPDATEDRAW;
			else if (upd == false && dra)
				return SceneState.DRAW;
			else if (upd && dra == false)
				return SceneState.UPDATE;
			else if (upd == false && dra == false)
				return SceneState.SLEEP;
			return SceneState.SLEEP;
		}
			
		void ChangeSceneState(bool upd, bool dra, AScene sceneToChange)
		{
			if (upd && dra)
				sceneToChange.sceneState = SceneState.UPDATEDRAW;
			else if (upd == false && dra)
				sceneToChange.sceneState = SceneState.DRAW;
			else if (upd && dra == false)
				sceneToChange.sceneState = SceneState.UPDATE;
			else if (upd == false && dra == false)
				sceneToChange.sceneState = SceneState.SLEEP;
		}

		/// <summary>
		/// We draw all the entity of our scene
		/// </summary>
		/// <param name="gameTime">Game time.</param>
		public override void Draw(GameTime gameTime)
		{
			base.Draw (gameTime);
		}
	}
}

