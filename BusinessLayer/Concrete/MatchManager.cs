﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class MatchManager : IMatchService
    {
        IMatchDal _matchDal;

        public MatchManager(IMatchDal matchDal)
        {
            _matchDal = matchDal;
        }

        public void TDelete(Match t)
        {
            _matchDal.Delete(t);
        }

        public Match TGetById(int id)
        {
            return _matchDal.GetById(id);
        }


        public List<Match> TGetListAll()
        {
            return _matchDal.GetListAll();
        }

        public List<Match> TGetMatchWithTeams()
        {
            return _matchDal.GetMatchWithTeams();
        }
        public List<Match> TGetMatchWithAllDetails()
        {
            return _matchDal.GetMatchWithAllDetails();
        }
        public Match TGetMatchWithTeamByID(int MatchID)
        {
            return _matchDal.GetMatchWithTeamByID(MatchID);
        }
        public Match TGetMatchWithAllDetailsByID(int MatchID)
        {
            return _matchDal.GetMatchWithAllDetailsByID(MatchID);
        }
        public void TInsert(Match t)
        {
            _matchDal.Insert(t);
        }

        public void TUpdate(Match t)
        {
            _matchDal.Update(t);
        }

      
    }
}
