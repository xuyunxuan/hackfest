﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PsUnit : MonoBehaviour 
{
    public string m_Description = "";
    public float m_ExistTime = 3f; //預設3秒
    private float m_ParticleTimer = 0f;
    private float m_ParticleLifeTime = 3f;

    private ParticleSystem[] m_Pss = null;

    private void Update()
    {
        this.m_ParticleTimer += Time.deltaTime;
        if (this.m_ParticleTimer > this.m_ParticleLifeTime)
        {
            m_ParticleTimer = 0;
            ParticleManager.Recover(this);
        }
    }

    public void SetLifeTime(float time)
    {
        m_ParticleLifeTime = time;
    }

    public void ActiveParticleSystem()
    {
        this.m_Pss = gameObject.GetComponentsInChildren<ParticleSystem>(true);
        for (int i = 0; i < this.m_Pss.Length; i++)
        {
            ParticleSystem particleSystem = this.m_Pss[i];
            if (particleSystem.gameObject.activeSelf)
            {
                particleSystem.Simulate(0f, true, true);
                particleSystem.Play();
            }
        }
    }
}
