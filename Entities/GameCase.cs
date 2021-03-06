using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace IsartPolarium
{
	public class GameCase : AEntity
	{

		public enum e_state
		{
			NONE,
			ON_DRAG,
			PILE,
			FACE,
			SPECIAL_PILE,
			SPECIAL_FACE,
			GRAY
		}

		//Initisation variable qui sert a la vérification afin de savoir si on peut passer sur la case ou pas
		private static GameCase lastCase;
		public Vector2 coordonnee;

		//Compte le nombre de case qui sont en on_drag
		public static int nbrOnDrag;

		//Sprite
		Sprite sg;
		Sprite bc;

		bool isAlreadyEven = false;

		Color dragColor = Color.Yellow;

		public e_state actualState = e_state.NONE;
		e_state saveState = e_state.NONE;
		e_state previousState = e_state.NONE;

		public GameCase (AScene scene) : base(scene)
		{

		}

		public override void Initialize()
		{
			base.Initialize ();
		}

		public override void LoadContent()
		{
			bc = new Sprite ("Case");
			sg = new Sprite ("Mouse");
			LinkSprite ("Test_Tile");
			sprite.position = new Vector2 (20f, 20f);

			sg.position = sprite.position;
			sprite.depth = 1f;
			sg.depth = 1f;

			base.LoadContent ();
		}

		public override void Update(GameTime gameTime)
		{
			// Hitbox des cases
			Rectangle area = hitBox;

			//Récupération des données à envoyer au Player:
			if (area.Contains (AdvancedMouse.Position) && AdvancedMouse.OnDrag () && !(actualState == e_state.ON_DRAG))
			{	
				//If it is the first case dragged of if the last case dragged was over.
				if (lastCase == null) {
					//Tell Player that the mouse is being dragged (to Player)
					Player.ChangePlayerState ("ON_DRAG_DOWN");
					//Tell Player the position of the case for placement
					Player.MovePlayer (sprite.position);

					saveState = actualState;
					actualState = e_state.ON_DRAG;
					LinkSprite (sg);
					sprite.depth = 0.5f;
					lastCase = this;

					//increment nbrOnDrag
					nbrOnDrag++;
				} else {
					// Si la dernière case est déjà passée
					if (lastCaseAround()) {

						//Change direction of the sprite
						if (lastCase.Position.Y < sprite.position.Y) {
							Player.ChangePlayerState ("ON_DRAG_DOWN");
						}else if(lastCase.Position.Y > sprite.position.Y){
							Player.ChangePlayerState ("ON_DRAG_UP");						
						}else if(lastCase.Position.X < sprite.position.X){
							Player.ChangePlayerState ("ON_DRAG_RIGHT");
						}else if(lastCase.Position.X > sprite.position.X){
							Player.ChangePlayerState ("ON_DRAG_LEFT");
						}

						saveState = actualState;
						actualState = e_state.ON_DRAG;
						// Tell Player not to move from his current position
						Player.MovePlayer (sprite.position);
						sprite.depth = 0.5f;
						LinkSprite (sg);
						lastCase = this;

						//increment nbrOnDrag
						nbrOnDrag++;
					}


				}
										

			}
			else if (actualState == e_state.ON_DRAG && AdvancedMouse.OnRelease ())
			{

				SwitchState (saveState);

				lastCase = null;
				LinkSprite (bc);
				
				//Tell Player that the button is released (to Player)
				if (Player.actualStateP == Player.f_state.ON_DRAG_DOWN){
					Player.ChangePlayerState ("ON_RELEASE_DOWN");
				}
				else if (Player.actualStateP == Player.f_state.ON_DRAG_UP){
					Player.ChangePlayerState ("ON_RELEASE_UP");
				}
				else if (Player.actualStateP == Player.f_state.ON_DRAG_RIGHT){
					Player.ChangePlayerState ("ON_RELEASE_RIGHT");
				}
				else if (Player.actualStateP == Player.f_state.ON_DRAG_LEFT){
					Player.ChangePlayerState ("ON_RELEASE_LEFT");
				}


				//reset variable
				nbrOnDrag = 0;	

			}/*else if(!_scene.sceneManager.igInterface.validateBtn.changed && AdvancedMouse.OnRelease()){
				Console.WriteLine ("rentre dedans ");
				SwitchState (saveState);

				lastCase = null;
				LinkSprite (bc);

				//reset variable
				nbrOnDrag = 0;
				_scene.sceneManager.igInterface.validateBtn.changed = false;
			}*/
				
				changeSpecialCase (nbrOnDrag);

			linkTile ();

			// Assignation de l'état actuel à l'état précédent
			previousState = actualState;

			base.Update (gameTime);
		}

		//Fonction qui permet de savoir si on peut repasser sur une ligne
		public  bool lastCaseAround() {
			return 	(lastCase.coordonnee.X == this.coordonnee.X - 1 && lastCase.coordonnee.Y == this.coordonnee.Y) ||
				(lastCase.coordonnee.X == this.coordonnee.X + 1 && lastCase.coordonnee.Y == this.coordonnee.Y) ||
				(lastCase.coordonnee.X == this.coordonnee.X && lastCase.coordonnee.Y == this.coordonnee.Y - 1 )||
				(lastCase.coordonnee.X == this.coordonnee.X && lastCase.coordonnee.Y == this.coordonnee.Y + 1);
		}

		public override void Draw(GameTime gameTime)
		{
			base.Draw (gameTime);
		}

		//Change state of tiles
		private void SwitchState(e_state lastState)
		{
			if (lastState == e_state.PILE) {
				actualState = e_state.FACE;
			} else if (lastState == e_state.GRAY) {
				actualState = e_state.GRAY;
			} else if (lastState == e_state.SPECIAL_FACE) {
				actualState = e_state.SPECIAL_PILE;
			} else if (lastState == e_state.SPECIAL_PILE) {
				actualState = e_state.SPECIAL_FACE;
			} else if (lastState == e_state.FACE) {
				actualState = e_state.PILE;
			}
		}

		//Link image to the tile
		private void linkTile(){

			if (actualState == previousState) {
				return;
			}

			switch (actualState) {
			case e_state.PILE:
				LinkSprite ("Orange_Tile");
				break;

			case e_state.FACE:
				LinkSprite ("Beige_Tile");
				break;

			case e_state.GRAY:
				LinkSprite ("Grey_Tile");
				break;

			case e_state.ON_DRAG:
				if (previousState == e_state.PILE || previousState == e_state.SPECIAL_PILE){
					LinkSprite ("Beige_Tile_Dragged");
				}
				else if(previousState == e_state.FACE || previousState == e_state.SPECIAL_FACE){
					LinkSprite ("Orange_Tile_Dragged");
				}
				else{
					LinkSprite ("Grey_Tile_Dragged");
				}
				break;

			case e_state.SPECIAL_FACE:
				LinkSprite ("Tile_SPE_FACE");
				break;

			case e_state.SPECIAL_PILE:
				LinkSprite ("Tile_SPE_PILE");
				break;

			}

			sprite.depth = 0.5f;
			sg.depth = 0.5f;

			//Changement de l'echelle des sprites
			//sprite.scale = 1f;
		}

		/// <summary>
		/// Change the special Case
		/// </summary>
		/// <param name="caseOnDrag">Number of case is on_drag</param>
		private void changeSpecialCase(int caseOnDrag){

			if (caseOnDrag % 2 != 0) {
				isAlreadyEven = false;
			}

			if (!isAlreadyEven) {
				//Verification if caseOnDrag is even and different to 0 and if the actualState of the case is Special Pile or Special Face
				if ((caseOnDrag != 0 && caseOnDrag % 2 == 0) && (actualState == e_state.SPECIAL_PILE || actualState == e_state.SPECIAL_FACE)) {

					Console.WriteLine ("Ca change");

					SwitchState (actualState);

					isAlreadyEven = true;
				}
			}
		}
	}
}
