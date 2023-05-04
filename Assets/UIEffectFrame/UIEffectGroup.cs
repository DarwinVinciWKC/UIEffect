using Coffee.UIExtensions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIEffectGroup : MonoBehaviour
{

	public List<UIEffect> uiEffects = new List<UIEffect>();
	// Use this for initialization
	void Start()
	{
		Debug.Log(transform.childCount);
		Graphic[] g_arr = transform.GetComponentsInChildren<Graphic>();
		Debug.Log(g_arr.Length);
		for (int i = 0; i < g_arr.Length; i++)
		{
			UIEffect uiEffect = g_arr[i].GetComponent<UIEffect>();
			if (uiEffect == null)
			{
				uiEffect = g_arr[i].gameObject.AddComponent<UIEffect>();
			}
			uiEffects.Add(uiEffect);
		}

	}
	public EffectMode n_EffectMode = EffectMode.None;
	public ColorMode n_ColorMode = ColorMode.Multiply;
	public BlurMode n_BlurMode = BlurMode.None;
	[Range(0, 1)]
	public float n_EffectFactor = 1;
	[Range(0, 1)]
	public float n_ColorFactor = 1;
	[Range(0, 1)]
	public float n_BlurFactor = 1;
	public bool n_AdvancedBlur = false;

	private EffectMode m_EffectMode = EffectMode.None;
	private ColorMode m_ColorMode = ColorMode.Multiply;
	private BlurMode m_BlurMode = BlurMode.None;
	[Range(0, 1)]
	private float m_EffectFactor = 1;
	[Range(0, 1)]
	private float m_ColorFactor = 1;
	[Range(0, 1)]
	private float m_BlurFactor = 1;
	private bool m_AdvancedBlur = false;

	public EffectMode effectMode
	{
		get { return m_EffectMode; }
		set
		{
			if (m_EffectMode == value) return;
			m_EffectMode = value;
			for (int i = 0; i < uiEffects.Count; i++)
			{
				uiEffects[i].effectMode = m_EffectMode;
			}
		}
	}
	
	public ColorMode colorMode
	{
		get { return m_ColorMode; }
		set
		{
			if (m_ColorMode == value) return;
			m_ColorMode = value;
			for (int i = 0; i < uiEffects.Count; i++)
			{
				uiEffects[i].colorMode = m_ColorMode;
			}
		}
	}

	
	public BlurMode blurMode
	{
		get { return m_BlurMode; }
		set
		{
			if (m_BlurMode == value) return;
			m_BlurMode = value;
			for (int i = 0; i < uiEffects.Count; i++)
			{
				uiEffects[i].blurMode = m_BlurMode;
			}
		}
	}
	
	public float effectFactor
	{
		get { return m_EffectFactor; }
		set
		{
			value = Mathf.Clamp(value, 0, 1);
			if (Mathf.Approximately(m_EffectFactor, value)) return;
			m_EffectFactor = value;
			for (int i = 0; i < uiEffects.Count; i++)
			{
				uiEffects[i].effectFactor = m_EffectFactor;
			}
		}
	}

	/// <summary>
	/// Color effect factor between 0(no effect) and 1(complete effect).
	/// </summary>
	public float colorFactor
	{
		get { return m_ColorFactor; }
		set
		{
			value = Mathf.Clamp(value, 0, 1);
			if (Mathf.Approximately(m_ColorFactor, value)) return;
			m_ColorFactor = value;
			for (int i = 0; i < uiEffects.Count; i++)
			{
				uiEffects[i].colorFactor = m_ColorFactor;
			}
		}
	}

	/// <summary>
	/// How far is the blurring from the graphic.
	/// </summary>
	public float blurFactor
	{
		get { return m_BlurFactor; }
		set
		{
			value = Mathf.Clamp(value, 0, 1);
			if (Mathf.Approximately(m_BlurFactor, value)) return;
			m_BlurFactor = value;
			for (int i = 0; i < uiEffects.Count; i++)
			{
				uiEffects[i].blurFactor = m_BlurFactor;
			}
		}
	}

	public bool advancedBlur
	{
		get { return m_AdvancedBlur; }
		set
		{
			if (m_AdvancedBlur == value) return;
			m_AdvancedBlur = value;
			for (int i = 0; i < uiEffects.Count; i++)
			{
				uiEffects[i].advancedBlur = m_AdvancedBlur;
			}
		}
	}
	// Update is called once per frame
	void Update()
	{
		if (n_EffectMode != effectMode)
		{
			effectMode = n_EffectMode;
		}
		if (n_ColorMode != colorMode)
		{
			colorMode = n_ColorMode;
		}
		if (n_BlurMode != blurMode)
		{
			blurMode = n_BlurMode;
		}
		if (n_EffectFactor != effectFactor)
		{
			effectFactor = n_EffectFactor;
		}
		if (n_ColorFactor != colorFactor)
		{
			colorFactor = n_ColorFactor;
		}
		if (n_BlurFactor != blurFactor)
		{
			blurFactor = n_BlurFactor;
		}
		if (n_AdvancedBlur != advancedBlur)
		{
			advancedBlur = n_AdvancedBlur;
		}
	}
}
