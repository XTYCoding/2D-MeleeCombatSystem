using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

// 玩家技能管理器，负责技能切换与管理
public class PlayerSkillManager : MonoBehaviour
{
    public static PlayerSkillManager instance; // 单例实例
    public bool canChangeSkill = true; // 是否允许切换技能
    public Player player; // 玩家对象引用

    public Skill upSkill;    // 上方向技能
    public Skill downSkill;  // 下方向技能
    public Skill leftSkill;  // 左方向技能
    public Skill rightSkill; // 右方向技能

    public Skill currentSkill; // 当前选中的技能

    // 初始化单例和技能对象
    void Awake()
    {
        if (instance != null)
            Destroy(instance.gameObject); // 保证只有一个实例
        else instance = this;

        upSkill = new LightCut();      // 实例化上方向技能
        downSkill = new ShiledCast();  // 实例化下方向技能
        leftSkill = new HolySlash();   // 实例化左方向技能
    }

    // 注册十字键技能切换事件
    void Start()
    {
        player.playerInput.GamePlay.ChangeSkill.performed += OnDPadPerformed;
    }

    // 十字键输入回调，根据方向切换技能
    private void OnDPadPerformed(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if (!canChangeSkill) return; // 不允许切换时直接返回

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

    // 注销事件
    void OnDestroy()
    {
        player.playerInput.GamePlay.ChangeSkill.performed -= OnDPadPerformed;
    }
}