import React, {useState} from 'react';
import Taro, {useDidShow} from '@tarojs/taro';
import {AtIcon} from 'taro-ui';
import {View} from '@tarojs/components';

import styles from './add-to-favorite-prompt.module.scss';
const STORAGE_KEY = 'addToFavoritePromptShown';

let havePrompted = Taro.getStorageSync(STORAGE_KEY);
const menuBoundingRect = Taro.getMenuButtonBoundingClientRect();
const promptPostion = {
  top: menuBoundingRect.bottom,
  arrow: {
    left: menuBoundingRect.left + menuBoundingRect.width / 4,
  },
  card: {
    right: Taro.getSystemInfoSync().windowWidth - menuBoundingRect.right,
  },
};

const AddToFavoritePrompt = () => {
  const [shouldShow, toggleShow] = useState(false);

  const handleClosePrompt = () => {
    toggleShow(false);
    Taro.setStorageSync(STORAGE_KEY, true);
    havePrompted = true;
  };

  useDidShow(() => {
    if (havePrompted) return;
    window.setTimeout(() => toggleShow(true), 5000);
  });
  return shouldShow ? (
    <View className={styles.prompt}>
      <View
        className={styles.arrow}
        style={{left: promptPostion.arrow.left}}
      ></View>
      <View className={styles.card} style={{right: promptPostion.card.right}}>
        <View>
          <View>添加到我的小程序</View>
          <View className={styles.smallText}>福州话随手查</View>
        </View>
        <AtIcon onClick={handleClosePrompt} value='close' size={18} />
      </View>
    </View>
  ) : null;
};

export default AddToFavoritePrompt;
