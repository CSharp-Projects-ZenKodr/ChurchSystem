﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using ChurchSystem.App.ViewsModels;
using ChurchSystem.Business.Interfaces;
using ChurchSystem.Business.Models;

namespace ChurchSystem.App.Controllers
{
    public class MemberController : BaseController
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IMapper _mapper;

        public MemberController(IMemberRepository memberRepository, IMapper mapper)
        {
            _memberRepository = memberRepository;
            _mapper = mapper;
        }

        // GET: Members
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<MemberViewModel>>(await _memberRepository.GetEntities()));
        }

        // GET: Member/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            MemberViewModel memberViewModel = await GetMember(id);

            if (memberViewModel == null)
            {
                return NotFound();
            }

            return View(memberViewModel);
        }

        // GET: Member/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Member/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MemberViewModel memberViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(memberViewModel);
            }

            Member member = _mapper.Map<Member>(memberViewModel);
            await _memberRepository.CreateEntity(member);

            return RedirectToAction("Index");
        }

        // GET: Member/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            MemberViewModel memberViewModel = await GetMember(id);

            if (memberViewModel == null)
            {
                return NotFound();
            }

            return View(memberViewModel);
        }

        // POST: Member/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, MemberViewModel memberViewModel)
        {
            if (id != memberViewModel.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(memberViewModel);
            }

            Member member = _mapper.Map<Member>(memberViewModel);
            await _memberRepository.UpdateEntity(member);

            return RedirectToAction("Index");
        }

        // GET: Member/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            MemberViewModel memberViewModel = await GetMember(id);

            if (memberViewModel == null)
            {
                return NotFound();
            }

            return View(memberViewModel);
        }

        // POST: Member/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            MemberViewModel memberViewModel = await GetMember(id);

            if (memberViewModel == null)
            {
                return NotFound();
            }

            await _memberRepository.DeleteEntity(id);

            return RedirectToAction("Index");
        }

        private async Task<MemberViewModel> GetMember(Guid id)
        {
            return _mapper.Map<MemberViewModel>(await _memberRepository.GetEntityById(id));
        }
    }
}
