using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchFollow : MonoBehaviour
{

       [SerializeField] private GameObject leftArrow;
       [SerializeField] private GameObject rightArrow;
       [SerializeField] private GameObject upArrow;
       [SerializeField] private GameObject fire;

       private Camera _camera;

       private Vector3 _leftArrowPosition;

       private Vector3 _rightArrowPosition;

       private Vector3 _upArrowPosition;

       private Vector3 _firePosition;

       private Vector2 _leftArrowBoxHalf;
       private Vector2 _rightArrowBoxHalf;
       private Vector2 _upArrowBoxHalf;
       private Vector2 _fireBoxHalf;

       private bool _leftArrowTriggered = false;
       private bool _rightArrowTriggered = false;
       private bool _upArrowTriggered = false;
       private bool _fireTriggered = false;


       public bool LeftArrowTriggered => _leftArrowTriggered;
       public bool RightArrowTriggered => _rightArrowTriggered;
       public bool UpArrowTriggered => _upArrowTriggered;
       public bool FireTriggered => _fireTriggered;

       // Start is called before the first frame update
    void Start()
    {
           _camera = Camera.main;
    //       var leftArrow = new Vector2(-12, -6);
     //      var rightArrow =new Vector2(-8 , -6);
     
     //getting the positions of the control buttons
           _leftArrowPosition = leftArrow.transform.position;
           _rightArrowPosition = rightArrow.transform.position;
           _upArrowPosition = upArrow.transform.position;
           _firePosition = fire.transform.position;
       
     //the colliders of the controls buttons
           var leftArrowBox = leftArrow.GetComponent<BoxCollider2D>();
           var compt = leftArrowBox.size;
           _leftArrowBoxHalf = compt / 2;
           _rightArrowBoxHalf = rightArrow.GetComponent<BoxCollider2D>().size / 2;
           _upArrowBoxHalf = upArrow.GetComponent<BoxCollider2D>().size / 2;
           _fireBoxHalf = fire.GetComponent<BoxCollider2D>().size / 2;



    }

    // Update is called once per frame
    void Update()
    {
           var touchPosition = Input.mousePosition;
           touchPosition = _camera.ScreenToWorldPoint(touchPosition);
        //   print("postion : " +touchPosition);

        //checking if left arrow button is touched
        LeftButtonTrigger(touchPosition);
        
        //checking if right arrow is touch triggered
        RightButtonTrigger(touchPosition);   
        
        //checking if UP arrow is touch triggered
        UpButtonTrigger(touchPosition);
        
        


//       print("touch : "+_leftArrowTriggered);

    }

    void LeftButtonTrigger(Vector3 touchPosition)
    {
           //checking if left button is touch triggered
           
           if ((touchPosition.x >= _leftArrowPosition.x - _leftArrowBoxHalf.x) &&
               (touchPosition.x <= _leftArrowPosition.x + _leftArrowBoxHalf.x))
           {
                  if ((touchPosition.y >= _leftArrowPosition.y - _leftArrowBoxHalf.y) &&
                      (touchPosition.y <= _leftArrowPosition.y + _leftArrowBoxHalf.y))
                  {
                         _leftArrowTriggered = true;
                         //  print("pos : "+touchPosition); 
                  }
                  else
                  {
                         _leftArrowTriggered = false;
                  }
               
           }
           else
           {
                  _leftArrowTriggered = false;
           }
    }

    void RightButtonTrigger(Vector3 touchPosition)
    {
         //checking if right button is touch triggered
         if ((touchPosition.x >= _rightArrowPosition.x - _rightArrowBoxHalf.x) &&
             (touchPosition.x <= _rightArrowPosition.x + _rightArrowBoxHalf.x))
         {
                if ((touchPosition.y >= _rightArrowPosition.y - _rightArrowBoxHalf.y) &&
                    (touchPosition.y <= _rightArrowPosition.y + _rightArrowBoxHalf.y))
                {
                       _rightArrowTriggered = true;
                       //  print("pos : "+touchPosition); 
                }
                else
                {
                       _rightArrowTriggered = false;
                }
               
         }
         else
         {
                _rightArrowTriggered = false;
         }
    }



    void UpButtonTrigger(Vector3 touchPosition)
    {
           //checking if UP button is touch triggered
           
           if ((touchPosition.x >= _upArrowPosition.x - _upArrowBoxHalf.x) &&
               (touchPosition.x <= _upArrowPosition.x + _upArrowBoxHalf.x))
           {
                  if ((touchPosition.y >= _upArrowPosition.y - _upArrowBoxHalf.y) &&
                      (touchPosition.y <= _upArrowPosition.y + _upArrowBoxHalf.y))
                  {
                         _upArrowTriggered = true;
                         //  print("pos : "+touchPosition); 
                  }
                  else
                  {
                         _upArrowTriggered = false;
                  }
               
           }
           else
           {
                  _upArrowTriggered = false;
           }
    }
    
    
    
}
