using UnityEngine;
using UnityEditor;
using UnityEditor.AnimatedValues;

[CustomEditor(typeof(AICarController))]
[System.Serializable]
public class AIEditor : Editor{

  enum displayFieldType {DisplayAsAutomaticFields, DisplayAsCustomizableGUIFields}
  displayFieldType DisplayFieldType;

  private AICarController AICar;
  private SerializedObject SO;
  //
  //
  //PLAYER
  //
  //
  private SerializedProperty player;
  //
  //
  //EXPLOSION
  //
  //
  private SerializedProperty explosion;
  //
  //
  //CAR SETUP
  //
  //
  private SerializedProperty maxSpeed;
  private SerializedProperty maxReverseSpeed;
  private SerializedProperty accelerationMultiplier;
  private SerializedProperty maxSteeringAngle;
  private SerializedProperty steeringSpeed;
  private SerializedProperty brakeForce;
  private SerializedProperty decelerationMultiplier;
  private SerializedProperty handbrakeDriftMultiplier;
  private SerializedProperty driftStart;
  public SerializedProperty turnThreshold;
  public SerializedProperty overturn;
  public SerializedProperty rayRange;
  public SerializedProperty targetSpeed;
  private SerializedProperty bodyMassCenter;
  //
  //
  //WHEELS VARIABLES
  //
  //
  private SerializedProperty frontLeftMesh;
  private SerializedProperty frontLeftCollider;
  private SerializedProperty frontRightMesh;
  private SerializedProperty frontRightCollider;
  private SerializedProperty rearLeftMesh;
  private SerializedProperty rearLeftCollider;
  private SerializedProperty rearRightMesh;
  private SerializedProperty rearRightCollider;
  //
  //
  //PARTICLE SYSTEMS' VARIABLES
  //
  //
  private SerializedProperty useEffects;
  private SerializedProperty RLWParticleSystem;
  private SerializedProperty RRWParticleSystem;
  private SerializedProperty RLWTireSkid;
  private SerializedProperty RRWTireSkid;
  //
  //
  //SPEED TEXT (UI) VARIABLES
  //
  //
  private SerializedProperty useUI;
  private SerializedProperty carSpeedText;
  //
  //
  //SPEED TEXT (UI) VARIABLES
  //
  //
  private SerializedProperty useSounds;
  private SerializedProperty carEngineSound;
  private SerializedProperty tireScreechSound;

  private void OnEnable(){
    AICar = (AICarController)target;
    SO = new SerializedObject(target);

    player = SO.FindProperty("player");
    explosion = SO.FindProperty("explosion");

    maxSpeed = SO.FindProperty("maxSpeed");
    maxReverseSpeed = SO.FindProperty("maxReverseSpeed");
    accelerationMultiplier = SO.FindProperty("accelerationMultiplier");
    maxSteeringAngle = SO.FindProperty("maxSteeringAngle");
    steeringSpeed = SO.FindProperty("steeringSpeed");
    brakeForce = SO.FindProperty("brakeForce");
    decelerationMultiplier = SO.FindProperty("decelerationMultiplier");
    handbrakeDriftMultiplier = SO.FindProperty("handbrakeDriftMultiplier");
    driftStart = SO.FindProperty("driftStart");
    turnThreshold = SO.FindProperty("turnThreshold");
    overturn = SO.FindProperty("overturn");
    rayRange = SO.FindProperty("rayRange");
    targetSpeed = SO.FindProperty("targetSpeed");
    bodyMassCenter = SO.FindProperty("bodyMassCenter");

    frontLeftMesh = SO.FindProperty("frontLeftMesh");
    frontLeftCollider = SO.FindProperty("frontLeftCollider");
    frontRightMesh = SO.FindProperty("frontRightMesh");
    frontRightCollider = SO.FindProperty("frontRightCollider");
    rearLeftMesh = SO.FindProperty("rearLeftMesh");
    rearLeftCollider = SO.FindProperty("rearLeftCollider");
    rearRightMesh = SO.FindProperty("rearRightMesh");
    rearRightCollider = SO.FindProperty("rearRightCollider");

    useEffects = SO.FindProperty("useEffects");
    RLWParticleSystem = SO.FindProperty("RLWParticleSystem");
    RRWParticleSystem = SO.FindProperty("RRWParticleSystem");
    RLWTireSkid = SO.FindProperty("RLWTireSkid");
    RRWTireSkid = SO.FindProperty("RRWTireSkid");

    useUI = SO.FindProperty("useUI");
    carSpeedText = SO.FindProperty("carSpeedText");

    useSounds = SO.FindProperty("useSounds");
    carEngineSound = SO.FindProperty("carEngineSound");
    tireScreechSound = SO.FindProperty("tireScreechSound");

  }

  public override void OnInspectorGUI(){

    SO.Update();

    GUILayout.Space(20);
    //
    //
    //PLAYER
    //
    //
    EditorGUILayout.PropertyField(player, new GUIContent("Player: "));
    EditorGUILayout.PropertyField(explosion, new GUIContent("Explosion : "));

    GUILayout.Space(25);
    GUILayout.Label("CAR SETUP", EditorStyles.boldLabel);
    GUILayout.Space(10);

    //
    //
    //CAR SETUP
    //
    //
    //
    maxSpeed.intValue = EditorGUILayout.IntSlider("Max Speed:", maxSpeed.intValue, 20, 300);
    maxReverseSpeed.intValue = EditorGUILayout.IntSlider("Max Reverse Speed:", maxReverseSpeed.intValue, 10, 120);
    accelerationMultiplier.intValue = EditorGUILayout.IntSlider("Acceleration Multiplier:", accelerationMultiplier.intValue, 1, 30);
    maxSteeringAngle.intValue = EditorGUILayout.IntSlider("Max Steering Angle:", maxSteeringAngle.intValue, 10, 45);
    steeringSpeed.floatValue = EditorGUILayout.Slider("Steering Speed:", steeringSpeed.floatValue, 0.1f, 1f);
    brakeForce.intValue = EditorGUILayout.IntSlider("Brake Force:", brakeForce.intValue, 100, 600);
    decelerationMultiplier.intValue = EditorGUILayout.IntSlider("Deceleration Multiplier:", decelerationMultiplier.intValue, 1, 10);
    handbrakeDriftMultiplier.intValue = EditorGUILayout.IntSlider("Drift Multiplier:", handbrakeDriftMultiplier.intValue, 1, 10);
    driftStart.floatValue = EditorGUILayout.Slider("Drift Start:", driftStart.floatValue, 1f, 10f);
    turnThreshold.floatValue = EditorGUILayout.Slider("Turn Threshold : ", turnThreshold.floatValue,5f,40f);
    overturn.floatValue = EditorGUILayout.Slider("Overturn Angle : ", overturn.floatValue,0.01f,0.25f);
    rayRange.floatValue = EditorGUILayout.Slider("Ray Range : ",rayRange.floatValue,10f,50f);
    targetSpeed.floatValue = EditorGUILayout.Slider("Target Speed : ",targetSpeed.floatValue,50f,120f);
    EditorGUILayout.PropertyField(bodyMassCenter, new GUIContent("Mass Center of Car: "));

    //
    //
    //WHEELS
    //
    //

    GUILayout.Space(25);
    GUILayout.Label("WHEELS", EditorStyles.boldLabel);
    GUILayout.Space(10);

    EditorGUILayout.PropertyField(frontLeftMesh, new GUIContent("Front Left Mesh: "));
    EditorGUILayout.PropertyField(frontLeftCollider, new GUIContent("Front Left Collider: "));

    EditorGUILayout.PropertyField(frontRightMesh, new GUIContent("Front Right Mesh: "));
    EditorGUILayout.PropertyField(frontRightCollider, new GUIContent("Front Right Collider: "));

    EditorGUILayout.PropertyField(rearLeftMesh, new GUIContent("Rear Left Mesh: "));
    EditorGUILayout.PropertyField(rearLeftCollider, new GUIContent("Rear Left Collider: "));

    EditorGUILayout.PropertyField(rearRightMesh, new GUIContent("Rear Right Mesh: "));
    EditorGUILayout.PropertyField(rearRightCollider, new GUIContent("Rear Right Collider: "));

    //
    //
    //EFFECTS
    //
    //

    GUILayout.Space(25);
    GUILayout.Label("EFFECTS", EditorStyles.boldLabel);
    GUILayout.Space(10);

    useEffects.boolValue = EditorGUILayout.BeginToggleGroup("Use effects (particle systems)?", useEffects.boolValue);
    GUILayout.Space(10);

        EditorGUILayout.PropertyField(RLWParticleSystem, new GUIContent("Rear Left Particle System: "));
        EditorGUILayout.PropertyField(RRWParticleSystem, new GUIContent("Rear Right Particle System: "));

        EditorGUILayout.PropertyField(RLWTireSkid, new GUIContent("Rear Left Trail Renderer: "));
        EditorGUILayout.PropertyField(RRWTireSkid, new GUIContent("Rear Right Trail Renderer: "));

    EditorGUILayout.EndToggleGroup();

    //
    //
    //UI
    //
    //

    GUILayout.Space(25);
    GUILayout.Label("UI", EditorStyles.boldLabel);
    GUILayout.Space(10);

    useUI.boolValue = EditorGUILayout.BeginToggleGroup("Use UI (Speed text)?", useUI.boolValue);
    GUILayout.Space(10);

        EditorGUILayout.PropertyField(carSpeedText, new GUIContent("Speed Text (UI): "));

    EditorGUILayout.EndToggleGroup();

    //
    //
    //SOUNDS
    //
    //

    GUILayout.Space(25);
    GUILayout.Label("SOUNDS", EditorStyles.boldLabel);
    GUILayout.Space(10);

    useSounds.boolValue = EditorGUILayout.BeginToggleGroup("Use sounds (car sounds)?", useSounds.boolValue);
    GUILayout.Space(10);

        EditorGUILayout.PropertyField(carEngineSound, new GUIContent("Car Engine Sound: "));
        EditorGUILayout.PropertyField(tireScreechSound, new GUIContent("Tire Screech Sound: "));

    EditorGUILayout.EndToggleGroup();

    //END

    GUILayout.Space(10);
    SO.ApplyModifiedProperties();

  }

}