import { AppState } from '../AppState'
import { logger } from '../utils/Logger'
import { api } from './AxiosService'

class ProfileService {
  async getProfile() {
    try {
      const res = await api.get('api/profiles')
      AppState.userProfile = res.data
      profileService.getUserVaults(AppState.userProfile.id)
      profileService.getUserKeeps(AppState.userProfile.id)
      logger.log('userProfile', AppState.userProfile)
    } catch (err) {
      logger.error('HAVE YOU STARTED YOUR SERVER YET???', err)
    }
  }

  async getOneProfile(id) {
    try {
      const res = await api.get('api/profiles/' + id)
      AppState.activeProfile = res.data
      logger.log('going to get profile keeps and vaults')
      this.getProfileVaults(id)
      this.getProfileKeeps(id)
      logger.log('ps.getOneProfile appState.activeProfile, appstate.profile', AppState.activeProfile, AppState.profile)
    } catch (e) {
      logger.log(e)
    }
  }

  async getUserVaults(id) {
    try {
      logger.log('api/profiles/id/vaults profileId', id)
      const res = await api.get('api/profiles/' + id + '/vaults')
      AppState.userVaults = res.data
      logger.log('res/api/profile/id/vaults  appState.userVaults', AppState.userVaults)
    } catch (e) {
      logger.log('Profile Service', e)
    }
  }

  async getProfileVaults(id) {
    try {
      logger.log('api/profiles/id/vaults profileId', id)
      const res = await api.get('api/profiles/' + id + '/vaults')
      AppState.activeProfileVaults = res.data
      logger.log('res/api/profile/id/vaults  activeProfileVaults', AppState.activeProfileVaults)
    } catch (e) {
      logger.log('Profile Service', e)
    }
  }

  async getProfileKeeps(id) {
    try {
      logger.log('api/profiles/id/keeps/', id)
      const res = await api.get('api/profiles/' + id + '/keeps')
      AppState.activeProfileKeeps = res.data
      logger.log('res/api/profiles/id/keeps', id, res.data)
    } catch (e) {
      logger.log(e)
    }
  }

  async getUserKeeps(id) {
    try {
      logger.log('api/profiles/id/keeps/', id)
      const res = await api.get('api/profiles/' + id + '/keeps')
      AppState.userKeeps = res.data
      logger.log('res/api/profiles/id/keeps userkeeps', id, AppState.userKeeps)
    } catch (e) {
      logger.log(e)
    }
  }
}

export const profileService = new ProfileService()
