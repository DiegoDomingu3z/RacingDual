import { api } from './AxiosService'
import { AppState } from '../AppState'
import { logger } from '../utils/Logger'

class PostFeedService {
    async getAllPosts() {
        const res = await api.get('api/posts')
        logger.log(res.data)
        AppState.posts = res.data
    }

}



export const postFeedService = new PostFeedService()