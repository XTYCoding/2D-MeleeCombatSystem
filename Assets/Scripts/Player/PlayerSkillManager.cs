using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerSkillManager : MonoBehaviour
{
    public static PlayerSkillManager instance;
    public bool canChangeSkill = true;
    public Player player;

    public Skill upSkill;
    public Skill downSkill;
    public Skill leftSkill;
    public Skill rightSkill;

    public Skill currentSkill;



    void Awake()
    {
        if (instance != null)
            Destroy(instance.gameObject);
        else instance = this;

        upSkill = new LightCut();
        downSkill = new ShiledCast();
        leftSkill = new HolySlash();
    }

    void Start()
    {
        player.playerInput.GamePlay.ChangeSkill.performed += OnDPadPerformed;
        

    }
    

    
    private void OnDPadPerformed(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if (!canChangeSkill) return;
        Vector2 dpad = context.ReadValue<Vector2>();
        if (dpad == Vector2.zero) return;

        // 优先判断上下左右
        if (dpad.y > 0.5f)
            currentSkill = upSkill;
        else if (dpad.y < -0.5f)
            currentSkill = downSkill;
        else if (dpad.x < -0.5f)
            currentSkill = leftSkill;
        else if (dpad.x > 0.5f)
            currentSkill = rightSkill;

        Debug.Log("当前技能切换为: " + currentSkill.skillName);
    }

    void OnDestroy()
    {
        player.playerInput.GamePlay.ChangeSkill.performed -= OnDPadPerformed;

}



}
