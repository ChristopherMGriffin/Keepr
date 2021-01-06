import { AppState } from '../AppState'
import { logger } from '../utils/Logger'
import { api } from './AxiosService'

class ProfileService {
  async getProfile() {
    try {
      const res = await api.get('api/profile')
      AppState.profile = res.data
      this.getProfileVaults(AppState.profile.id)
      logger.log(AppState.P)
    } catch (err) {
      logger.error('HAVE YOU STARTED YOUR SERVER YET???', err)
    }
  }

  async getOneProfile(id) {
    try {
      const res = await api.get('api/profile/' + id)
      AppState.activeProfile = res.data
      logger.log('activeProfile', AppState.activeProfile)
    } catch (e) {
      logger.log(e)
    }
  }

  async getProfileVaults(id) {
    try {
      logger.log('profileId', id)
      const res = await api.get('api/profile/' + id + '/vaults')
      AppState.profileVaults = res.data
      logger.log('profileVaults', AppState.profileVaults)
    } catch (e) {
      logger.log('Profile Service', e)
    }
  }

  async getProfileKeeps(id) {
    try {
      logger.log('profile Keeps', id)
      const res = await api.get('api/profile/' + id + '/keeps')
      AppState.profileKeeps = res.data
      logger.log('profile Keeps', id, res.data)
    } catch (e) {
      logger.log(e)
    }
  }
}

export const profileService = new ProfileService()
