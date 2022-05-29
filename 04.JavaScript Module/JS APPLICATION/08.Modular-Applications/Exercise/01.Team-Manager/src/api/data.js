import * as api from './api.js';

const endPoints = {
    'getAllTeams': '/data/teams',
  'getUserTeams': (userId) =>`/data/members?where=_ownerId%3D%22${userId}%22%20AND%20status%3D%22member%22&load=team%3DteamId%3Ateams`,
  'getTeamUsers': (teamId) => `/data/members?where=teamId%3D%22${teamId}%22&load=user%3D_ownerId%3Ausers`,
  'getTeamById': '/data/teams/',
  'getListOfMembers': (teamId, count) => `/data/members?where=teamId%3D%22${teamId}%22&load=user%3D_ownerId%3Ausers${count ? '&count' : ''}`,
  'getUserById': '/data/members/',
  'editTeam': '/data/teams/',
  'createTeam': '/data/teams',
  'becomeMember': '/data/members',
  'setMember': '/data/members/',
  'deleteMember': '/data/members/'
}


export async function getUserTeams(userId) {
    return await api.get(endPoints.getUserTeams(userId)); 
}


export async function getAllTeams() {
    return await api.get(endPoints.getAllTeams); 
}

export async function getTeamUsers(teamId) {
    return await api.get(endPoints.getTeamUsers(teamId)); 
}

export async function getTeamById(teamId) {
    return await api.get(endPoints.getTeamById + teamId);
}

export async function getTeamUserCount(teamId) {
    return await api.get(endPoints.getTeamUsersCount(teamId)); 
}

export async function getTeamMembers(teamId, count = false) {
    return await api.get(endPoints.getListOfMembers(teamId, count)); 
}

export async function getUserById(id) {
    return await api.get(endPoints.getUserById + id);
}

export async function editTeam(id, editedTeam) {
    await api.put(endPoints.editTeam + id, editedTeam);
}

export async function createTeam(team) {
    return await api.post(endPoints.createTeam, team);
}

export async function becomeMember(teamId) {
     return await api.post(endPoints.becomeMember, {teamId});
}

export async function setMemberStatus(userId, status = 'member') {
    await api.put(endPoints.setMember + userId, {status});
}

export async function deleteMember(memberId) {
    await api.del(endPoints.deleteMember + memberId);
}