using UnityEngine;

[CreateAssetMenu(fileName = "NewInputData", menuName = "ScriptableObjects/InputData")]
public class InputData : ScriptableObject
{
   private Vector2 _inputVector;
   private bool _goFast;
   private bool _goRotateLeft;
   private bool _goRotateRight;
   private bool _goZoom;
   private bool _goLeftMouseClick;
   

   public Vector2 InputVector => _inputVector;

   public bool GoLeftMouseClick
   {
      get => _goLeftMouseClick;
      set => _goLeftMouseClick = value;
   }
   
   public bool GoZoom
   {
      get => _goZoom;
      set => _goZoom = value;
   }

   public bool GoFast
   {
      get => _goFast;
      set => _goFast = value;
   }

   public bool GoRotateLeft
   {
      get => _goRotateLeft;
      set => _goRotateLeft = value;
   }
   
   public bool GoRotateRight
   {
      get => _goRotateRight;
      set => _goRotateRight = value;
   }
   
   public float InputVectorX
   {
      set => _inputVector.x = value;
   }

   public float InputVectorY
   {
      set => _inputVector.y = value;
   }
   
   
}
